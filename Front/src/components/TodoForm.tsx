import React, { Component } from "react"
import { TodoItemModel } from "../Models/TodoItem"
import { ApiTodo } from "../service/ApiTodo";

type Props = {
    ActionCreate: ((e:any) => void),
    outro: string
    
}
 type State = {
  todoItem: TodoItemModel
  teste:string
}


export class TodoForm extends React.Component<Props,State>{
    constructor(props:any) {
        super(props);
        this.state = {
            todoItem: {
                id:0,
                title:"",
                description:"",
                completed:false,
                createAt: new Date,
                updateAt: null
              },
              teste: this.props.outro
          };
      }

    handleSubmit = (e:React.FormEvent<HTMLFormElement>) => {
        e.preventDefault()
        
        this.props.ActionCreate(this.state.todoItem)
        //const result = ApiTodo.saveTodo(this.state.todoItem)
        
    }   

    render(){
        return(
            <form onSubmit={(e) => {this.handleSubmit(e)}}>
            <textarea
            className="input"
           value={this.state.todoItem.title}
            onChange={(e) => {
                this.setState({todoItem: {...this.state.todoItem, title: e.target.value} })}}
            />
            {/* // value={this.state.teste}
            // onChange={(e) => { this.setState({teste: e.target.value}) }}
            //    /> */}
            <button type="submit">Submit</button>
            </form>
        )
    }


}