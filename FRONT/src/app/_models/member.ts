import {Photo} from './photo';
import { Apartment } from "./apartment";
import { IAdress } from './adress';

export interface Member {
    id: number;
    username: string;
    age: number;
    rentedApartments: Apartment[]
    ownedApartments: Apartment[]
    
}
