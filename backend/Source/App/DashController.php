<?php

namespace Source\App;

use Psr\Http\Message\ResponseInterface as Response;
use Psr\Http\Message\ServerRequestInterface as Request;
use Source\Core\Authentication;
use Source\Models\User;
use Source\Models\Task;
use Source\Models\Situation;

class DashController {

    public function userTasks(Request $req, Response $res){

        $headers = $req->getHeaders();
        $token = $headers['Authorization'][0];

        $decode = Authentication::decode($token);
        $payload = $decode->payload;
        $idUser = $payload->id;

        $user = new User();
        $user->findById((Int) $idUser);

        $result = $user->raw("SELECT * FROM taskxmembers WHERE id_user = :id_user", [
            ":id_user"=> $idUser
        ]);

        $dataset = [];
        $dataset["tasks_count"] = 0;
        foreach ($result as $taskmember) {
            
            $task = new Task();
            $task->findById($taskmember->id_task);

            $date = new \DateTime();
            $formatedDate = $date->format('Y-m-d');
            
            if ($task->estimated_start == $formatedDate) {
                
                $dataset['tasks_count'] += 1;
            }

        }

        $res->getBody()->write(\json_encode($dataset));
        return $res->withHeader("Content-Type", "application/json");

    }

    public function dailyTasks(Request $req, Response $res){


        $task = new Task();
        $situation = new Situation();

        
        $date = new \DateTime;
        $startDate = $date->format("Y-m-d 00:00:00");
        $endDate = $date->format("Y-m-d 23:59:59");

        $concluded = $situation->find("concluded = :concluded", ":concluded=1")->fetch();

        $newTasks = $task->raw("SELECT * FROM tasks WHERE created_at BETWEEN :dtStart and :dtEnd", [
            ":dtStart" => $startDate,
            ":dtEnd" => $endDate
        ]);

        $closedToday = $task->raw("SELECT * FROM tasks WHERE id_situation = :id_situation and updated_at BETWEEN :dtStart and :dtEnd", [
            ":id_situation" => $concluded->id_situation,
            ":dtStart" => $startDate,
            ":dtEnd" => $endDate
        ]);

        $dataset = [
            "oppened" => count($newTasks),
            "closed" => count($closedToday)
        ];


        $res->getBody()->write(\json_encode($dataset));
        return $res->withHeader("Content-Type", "application/json");

    }

    public function situations(Request $req, Response $res){

        $situation = new Situation;
        $task = new Task;

        $situations = $situation->find()->fetch(true);

        
        $dataset = [];
        foreach ($situations as $row) {
            
            $tasks = $task->find("id_situation = :id_situation", ":id_situation={$row->id_situation}", "count(*) as count")->fetch();

            $dataset[] = [
                "situation" => $row->situation,
                "count" => $tasks->count
            ];

        }

        $res->getBody()->write(\json_encode($dataset));
        return $res->withHeader("Content-Type", "application/json");

    }

    public function taskHistory(Request $req, Response $res){

        $task = new Task();

        $dataset = [];
        for ($i = 3; $i >= 0; $i--){
            $date = new \DateTime;
            $interval =  new \DateInterval("P{$i}M");
            
            $date = $date->sub($interval);

            $firstDate = $date->format("Y-m-01 00:00:00");
            $lastDate = $date->format("Y-m-31 23:59:59");

            $result = $task->raw("SELECT COUNT(*) AS count FROM TASKS WHERE CREATED_AT BETWEEN :start AND :end ", [
                ":start" => $firstDate,
                ":end" => $lastDate
            ]);

            $period = $date->format("M") . "/" . $date->format("y");

            $dataset[] = [
                "period" => $period,
                "count" => $result[0]->count
            ];



        }
                

        $res->getBody()->write(\json_encode($dataset));
        return $res->withHeader("Content-Type", "application/json");

    }

    public function userPerformace(Request $req, Response $res){

        $headers = $req->getHeaders();
        $authorization = $headers['Authorization'][0];
        $token = Authentication::decode($authorization);

        $user = new User();
        $user->findById( (Int) $token->payload->id);

        $months = [];
        $dataset = [];

        for($i = 3; $i >= 0; $i--){

            $date = new \DateTime();
            $interval = new \DateInterval("P{$i}M");
            $date->sub($interval);

            $startDate = $date->format("Y-m-1");
            $endDate = $date->format("Y-m-31");
            $monthName = $date->format("M/y");

            $task = new Task();
            $assigned = $task->raw("SELECT * FROM taskxmembers WHERE id_user = :id_user AND created_at BETWEEN :startDate and :endDate  ", [
                ":id_user" => $user->id_user,
                ":startDate" => $startDate,
                ":endDate" => $endDate
            ]);

            $result = $task->find("tasks.concluded_at BETWEEN :startDate AND :endDate and taskxmembers.id_user = :idUser", ":startDate={$startDate}&:endDate={$endDate}&:idUser={$user->id_user}")->join("taskxmembers", "taskxmembers.id_task = tasks.id_task")->fetch(true);
            
            $dataset[$monthName] = [
                "assigned" => count($assigned),
                "concluded" => ($result !== false) ? count($result) : 0
            ];

        }

        $res->getBody()->write(\json_encode($dataset));
        return $res->withHeader("Content-Type", "application/json");

    }

    public function teamPerformace(Request $req, Response $res){

        $headers = $req->getHeaders();

        $months = [];
        $dataset = [];

        for($i = 3; $i >= 0; $i--){

            $date = new \DateTime();
            $interval = new \DateInterval("P{$i}M");
            $date->sub($interval);

            $startDate = $date->format("Y-m-1");
            $endDate = $date->format("Y-m-31");
            $monthName = $date->format("M/y");

            $task = new Task();
            $oppened = $task->raw("SELECT COUNT(*) AS count FROM TASKS WHERE CREATED_AT BETWEEN :start AND :end ", [
                ":start" => $startDate,
                ":end" => $endDate
            ]);

            $result = $task->find("concluded_at BETWEEN :startDate AND :endDate", ":startDate={$startDate}&:endDate={$endDate}")->fetch(true);
            

            $dataset[$monthName] = [
                "oppened" => $oppened[0]->count,
                "concluded" => ($result !== false) ? count($result) : 0
            ];

        }

        $res->getBody()->write(\json_encode($dataset));
        return $res->withHeader("Content-Type", "application/json");

    }
}