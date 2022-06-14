export interface IComment{
    ownerComment: string;
    apartmentComment: string;
    apartmentId: number
}
export class CommentClass{
    ownerComment:string="";
    apartmentComment:string="";
    apartmentId:number =0
}