import React, { useState, useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux';

import Icon from './../../../../components/Icon';
import NewTaskInput from './components/NewTaskInput';
import Select from './../../../../components/Select';
import Button from './../../../../components/Button';
import TextArea from './../../../../components/TextArea';
import ComboSelect from './../../../../components/ComboSelect';
import DetailtBox from './../../../../components/DetailBox';
import useHttp from './../../../../services/useHttp';

import './style.css';

const NewTicket = () =>{
    const { id_user: idUserCreation } = useSelector(state => state.user.authenticatedUser);
    const usersList = useSelector(state => state.user.usersList);
    
    const [members, setMembers] = useState([]);
    const [tags, setTags] = useState([]);
    const [taskTitle, setTaskTitle] = useState("");
    const [taskDescription, setTaskDescription] = useState("");
    const [selectedTags, setSelectedTags] = useState([]);
    const [selectedMembers, setSelectedMembers] = useState([]);
    const [idRequester, setRequester] = useState(0);
    
    
    const dispatch = useDispatch();
    const httpRequest = useHttp();

    useEffect(()=>{
        async function getAvailableMembers(){
            const request = await httpRequest("GET", "/available-members")
            if (!request)return false;
            
            const { data } = request;

            if (data.error){
                // Tratar erros
                return false;
            }

            setMembers(data);
        }

        getAvailableMembers();
    }, []);

    useEffect(()=>{
        async function getAvailableTags(){

            const response = await httpRequest("GET", '/available-tags');

            if (!response) return false;

            const { data } = response;

            if (data.error){
                return false;
            }

            const tags = data.map(tag => ({
                id: tag.id_tag,
                name: tag.title,
                background_color: tag.background_color,
                foreground_color: tag.foreground_color
            }));

            setTags(tags);
        }
        getAvailableTags();
    }, []);

    function handleCloseNTModal(e){
        if (e.target == e.currentTarget){
            // setModal(false);

            dispatch({
                type:"SHOW_NEW_TASK_MODAL",
                payload: false
            })

        }
    }

    async function handleSetSelectedMember(e){

        const { id } = e.target.dataset;

        if (selectedMembers.find(item=>item.id === id)) {

            const filteredMembers = selectedMembers.filter(item => item.id !== id);

            setSelectedMembers(filteredMembers);

        } else {
                    
            const response = await httpRequest("GET", `/user/${id}`);

            if (!response) return false;
            
            const { data } = response;

            setSelectedMembers([...selectedMembers, { ...data }]);
        }

    }

    async function handleSetSelectedTags(e){

        const { id } = e.target.dataset;

        if (selectedTags.find(tag=>tag.id === id)) {

            const filteredTags = selectedTags.filter(item=> item.id !== id);

            setSelectedTags(filteredTags);

        } else {

            const response = await httpRequest("GET", `/tag/${id}`);

            if (!response) return false;

            const { data } = response;

            const tag = [data].map(item=>({
                id: item.id_tag,
                title: item.title,
                background_color: item.background_color,
                foreground_color: item.foreground_color
            }))

            setSelectedTags([...selectedTags, { ...tag[0] }]);

        }
    }

    async function handleCreateNewTask(){

        const task = {
            title: taskTitle,
            description: taskDescription,
            id_requester: idRequester,
            id_user_creation: idUserCreation,
            selectedTags: selectedTags.map(item=>(item.id)),
            selectedMembers: selectedMembers.map(item => (item.id))
        }

        const response = await httpRequest("POST", '/task', task);

        if (!response) return false;

        const { data } = response;

        if  (data.error){
            dispatch({
                type: "SHOW_MODAL_MESSAGE",
                payload:{
                    title: "Ooops...",
                    message: `Houve um erro ao tentar cadastrar uma nova tarefa, por favor, contate um administrador`
                }
            });
            return false;
        }
       
        dispatch({
            type: "SHOW_MODAL_MESSAGE",
            payload:{
                title: "Sucesso",
                message: `Tarefa [${data.id_task}]${data.title} criada com sucesso.`
            }
        });

        setRequester(0);
        setTaskTitle("");
        setTaskDescription("");
        setSelectedMembers([]);
        setSelectedTags([]);

        dispatch({
            type:"SHOW_NEW_TASK_MODAL",
            payload: false
        })

        dispatch({
            type: 'LOAD_TASKS',
            payload: true
        });

    }

    return(
        <div 
            className={`new-ticket-container show`}
            onClick={handleCloseNTModal}
        >
            <section className="new-ticket-modal">
                
                <header className="modal-header">
                    <div className="new-ticket-title">
                        <NewTaskInput 
                            value={taskTitle}
                            onChange={(e) => setTaskTitle(e.target.value)}
                        />              
                    </div>                    
                    <div>
                        <div className="modal-close"
                            onClick={handleCloseNTModal}
                        >
                            <Icon 
                                iconName="FaWindowClose"
                            />
                        </div>
                    </div>
                </header>

                <div className="new-ticket-options">
                    <DetailtBox label="solicitante" >
                        <Select 
                            data={usersList} 
                            value={idRequester}
                            onChange={(e) => setRequester(e.target.value)}
                        />
                    </DetailtBox>

                    <DetailtBox label="Integrantes">
                        
                        <ComboSelect 
                            label="Integrantes"
                            data={members}
                            selectedItems={selectedMembers}
                            onSelect={handleSetSelectedMember}
                            rounded
                        />

                        <div className="selected-members-list">
                            {selectedMembers.map(member=>(
                                <img key={member.id} src={member.avatar} alt={member.name} title={member.name} />
                            ))}
                        </div>
                    </DetailtBox>
                </div>

                <DetailtBox label="etiquetas" >
                    <ComboSelect 
                        label="Etiquetas"
                        data={tags}
                        selectedItems={selectedTags}
                        onSelect={handleSetSelectedTags}
                    />

                    <div className="selected-tags-list">
                        {selectedTags.map(tag=>(
                            <span 
                                key={tag.id}
                                style={{
                                    backgroundColor: tag.background_color,
                                    color: tag.foreground_color
                                }}
                            >
                                {tag.title}
                            </span>
                        ))}
                    </div>
                </DetailtBox>

                <DetailtBox label="Descri????o" >
                    <TextArea
                        value={taskDescription}
                        onChange={(e)=>setTaskDescription(e.target.value)}
                    ></TextArea>
                </DetailtBox>

                <DetailtBox>
                    <Button
                        icon="FaCheck"
                        color="blue"
                        onClick={handleCreateNewTask}
                    > Abrir Tarefa </Button>
                </DetailtBox>

            </section>
        </div>
    )
}

export default NewTicket;