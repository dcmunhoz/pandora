import React from "react";
import Icon from "./../Icon";

import './style.css';

const Button = (props) =>{

    return(
        <button 
            {...props}
            className={`btn ${(props.color) ? 'btn_' + props.color : ''} ${(props.size) ? 'btn_' + props.size : ''} ${props.className}  `} 
            onClick={props.onClick} 
        > 

            {(props.icon) ? <Icon iconName={props.icon} color={props.iconColor} /> : null }      

            { props.children ?? null }

        </button>
    );  
}  

export default Button;  