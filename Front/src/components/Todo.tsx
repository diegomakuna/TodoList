import React, { Component } from "react"
import { TodoItemModel } from "../Models/TodoItem";
import { ApiTodo } from "../service/ApiTodo";
import { TodoForm } from "./TodoForm";
import { TodoItem } from "./TodoItem";


 type States = {
  todoItens?: TodoItemModel[] ;
}

type Props = {}

export class Todo extends React.Component<Props,States> {
    constructor(props:Props) {
        super(props);
        this.state = {
          todoItens: [],
          
        }
       // this.createTodo = this.createTodo.bind(this);
      }


      async componentDidMount() {
           this.LoadAll();
      }
      
       async createTodo(value:TodoItemModel) {
         console.log(this)
        const result = await ApiTodo.saveTodo(value)
        
          await this.LoadAll();
        
      }

      async deleteTodo(id:number) {
        
        await ApiTodo.deleteTodo(id)
        await this.LoadAll();
       
     }


      async LoadAll(){
        let result = await ApiTodo.getAllTodo();
        await this.setState({todoItens: result})
      }


      render(){
          return(
            <div className="todo-list">
              <TodoForm ActionCreate={(e) => this.createTodo(e)} outro="outrosaddasds" />
              {this.state.todoItens?.map((item, index) => <TodoItem 
              key={item.id} item={item} ActionDelete={(e) => this.deleteTodo(e) } />)  }
            </div>
          )
      }
}