import { type } from "node:os"
import React from "react"
import { TodoItemModel } from "../Models/TodoItem"

 type Props = {
    item: TodoItemModel
    ActionDelete?: ((e:any ) => void)
}

export const TodoItem: React.FC<Props> = ({
    item,
    ActionDelete = (e:number| undefined) => {},
   
}) => {
    
    return(
        <div className="todo" onClick={(e) => {ActionDelete(item.id)}}>

        <span dangerouslySetInnerHTML={{ __html: item.title }} /><br/>

          
           {item.description } <br />
           {item.completed } <br />
           {item.createAt } <br />
        </div>
    )
}