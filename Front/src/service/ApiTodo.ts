import { TodoItemModel } from "../Models/TodoItem";

export class ApiTodo {
  
  static  URL_API = "http://localhost:5000/Api"
    
  static async saveTodo(newtodo: TodoItemModel){

        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(newtodo)
        };
        const response = await fetch(`${this.URL_API}/TodoItem`, requestOptions);
        return  await response.json();
       
    }

    static async  getAllTodo():Promise<TodoItemModel[]> {

        const requestOptions = {
            method: 'Get',
            headers: { 'Content-Type': 'application/json' },
           
        };
        const response  = await fetch(`${this.URL_API}/TodoItem`, requestOptions);
        return await response.json();
       
    } 

    static async deleteTodo(id: number){

        const requestOptions = {
            method: 'DELETE',
            headers: { 'Content-Type': 'application/json' },
            
        };
        return  await fetch(`${this.URL_API}/TodoItem/${id}`, requestOptions);
         
       
    }
}