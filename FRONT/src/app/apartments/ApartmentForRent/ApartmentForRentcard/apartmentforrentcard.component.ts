import { Member } from '../../../_models/member';
import { Component, Input, OnInit } from '@angular/core';
import { Photo } from 'src/app/_models/photo';
import { Apartment } from 'src/app/_models/apartment';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { RentApComponent } from 'src/app/modals/rent-ap/rent-ap.component';

@Component({
  selector: 'app-member-card',
  templateUrl: './apartmentforrentcard.component.html',
  styleUrls: ['./apartmentforrentcard.component.css']
})
export class MemberCardComponent implements OnInit {
@Input() member: Member;
@Input() apartment: Apartment;
pic: string;
bsModalRef: BsModalRef;
  constructor(public modalService:BsModalService) {
    
   }

  ngOnInit(): void {
  }
  setDefaultPic(){
    this.pic="assets/NoImage.png";
  }
  openModal(apartment: Apartment){
    const config = {
      class: 'modal-dialog-center',
      initialState: {
        apartment
      }
    }
    this.bsModalRef = this.modalService.show(RentApComponent, config); 
  }
}
