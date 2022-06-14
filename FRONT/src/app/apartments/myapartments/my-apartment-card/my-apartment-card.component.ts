import { AddCommentModalComponent } from './../../../modals/add-comment-modal/add-comment-modal.component';
import { Component, Input, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Apartment, RentApartmentClass } from 'src/app/_models/apartment';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-my-apartment-card',
  templateUrl: './my-apartment-card.component.html',
  styleUrls: ['./my-apartment-card.component.css']
})
export class MyApartmentCardComponent implements OnInit {
  @Input() apartment: Apartment;
  bsModalRef: BsModalRef;
  constructor(public modalService:BsModalService,private router: Router,public accService:AccountService, public memberService:MembersService,private toastr: ToastrService) { }

  ngOnInit(): void {
  }


  onSubmit(form:NgForm){
    const user: User = JSON.parse(localStorage.getItem('user'));
    const id = this.accService.getUsername(user);
    this.memberService.reApformData.renterId=id;
    this.memberService.reApformData.apartmentId=this.apartment.id
    this.unRentApartment(form)
  
  }

  
  openModalComment(apartment: Apartment){
    const config = {
      class: 'modal-dialog-centered',
      initialState: {
        apartment
      }
    }
    this.bsModalRef = this.modalService.show(AddCommentModalComponent, config); 
  }


  unRentApartment(form:NgForm){
    this.memberService.unRentApartment().subscribe(
      res =>{
        this.memberService.reApformData = new RentApartmentClass();
        this.toastr.success('Najam je uspješno otkazan')
        window.setTimeout(function(){location.reload()},2000)
        
      },
      err =>{console.log(err);
     
      });
      
  }
}
