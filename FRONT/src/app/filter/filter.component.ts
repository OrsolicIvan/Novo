import { Component, OnInit, Pipe, PipeTransform } from '@angular/core';
import { Apartment } from '../_models/apartment';

@Pipe({ name: 'FFilter' })

export class Filter implements PipeTransform{

transform(aps: Apartment[], price:number,morePr:boolean, numRooms:number,moreRm:boolean,filt:boolean):any[]{
  if (!aps) {
    return [];
  }
  if (filt){return aps}
  else{
  if(morePr===true){
   aps = aps.filter(function(aps){
    console.log("DW")  
    return aps.monthlyPrice>=price
      
    })
  }
  else {
    aps = aps.filter(function(aps){
      console.log("ne")
      return aps.monthlyPrice<=price
    })
  }
  

  if(moreRm){
    aps = aps.filter(function(aps){
      return aps.numberOfRooms>=numRooms
    })
  }
  else {
    aps = aps.filter(function(aps){
      return aps.numberOfRooms<=numRooms
    })
  }
  return aps
}
  
  
  
}

}
