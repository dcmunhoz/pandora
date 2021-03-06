import React,{ useState } from 'react';
import { useDispatch } from 'react-redux';
import { useHistory, useLocation } from 'react-router-dom';

import Container from './../../components/Container';
import Input from './../../components/Input';
import Button from './../../components/Button';
import useHttp from '../../services/useHttp';
import auth from './../../services/auth';

import './style.css';

import logo from './../../images/logo.svg';

const Login = () => {
    let [username, setUser] = useState("");
    let [password, setPassword] = useState("");
    let dispatch = useDispatch();
    let history = useHistory();
    let httpRequest = useHttp();


    async function handleLogin(e){

        e.preventDefault();

        dispatch({
            type: "SHOW_LOADING_SCREEN"
        })

        let response = await httpRequest("POST", "/login", {
            username,
            password
        });
        
        dispatch({
            type: "HIDE_LOADING_SCREEN"
        })
        
        if (!response) return false;

        const { data } = response;

        if (data.error) {
            dispatch({
                type: "SHOW_MODAL_MESSAGE",
                payload: {
                    title: "Oooops...",
                    message: data.error
                }
            });;
            return
        }

        await auth.authenticate(data);

        

        history.replace("/");

        

    }

    return (
        <Container>
            
            <div className="loginContainer">
                
                <div className="login-box">
                    <header>
                        <img src={logo} alt=""/>
                    </header>
                    <form onSubmit={handleLogin}>
                        <section className="input-box">
                            <Input 
                                placeholder="Entre com seu usuário."
                                icon="FaUser"
                                value={username}
                                onChange={(e)=> {setUser(e.target.value)}}
                            />
                            <Input 
                                placeholder="Agora com sua senha."
                                type="password"
                                icon="FaKey"
                                value={password}
                                onChange={(e) => {setPassword(e.target.value)}}
                            />
                            <p>Esqueceu sua senha? <a href="">Clique Aqui !</a></p>
                        </section>

                        <section className="buttons-box">
                            <Button
                                color="green"
                                icon="FaSignInAlt"
                            >
                                Entrar
                            </Button>
                        </section>
                    </form>
                </div>

            </div>

        </Container>
    );    
}

export default Login;