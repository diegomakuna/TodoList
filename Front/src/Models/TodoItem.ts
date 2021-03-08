export type TodoItemModel = {
   
    id?:number 
    title: string,
    description:string 
    completed:boolean
    createAt?: Date | null
    updateAt?: string | null 
}