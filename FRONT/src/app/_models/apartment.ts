import { Adress, IAdress } from "./adress";
import { Photo } from "./photo";

export interface Apartment{
    id: number;
    apartmentDescription: string;
    numberOfRooms: number;
    monthlyPrice: number;
    ownerId: number;
    renterId:number;
    adress : IAdress[]
    photos : Photo[]
}
export class ApartmentClass{
    id: number= 0;
    apartmentDescription: string="";
    numberOfRooms: number=0;
    monthlyPrice: number=0;
    renterId: number = 0;
    ownerId: number=0;
}
export class RentApartmentClass{
    renterId:number=0;
    apartmentId: number=0;
    
}
export class UpApartmentClass{
    apartmentDescription: string="";
    numberOfRooms: number=0;
    monthlyPrice: number=0;}
