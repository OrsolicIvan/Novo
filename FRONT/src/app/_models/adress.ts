export interface IAdress{
    city: string;
    streetName: string;
    buildingNumber: number;
    apartmentNumber: number;
    apartmentId: number
}
export class Adress{
    city:string='';
    streetName:string='';
    buildingNumber:number=0;
    apartmentNumber:number=0;
    apartmentId:number=0
}