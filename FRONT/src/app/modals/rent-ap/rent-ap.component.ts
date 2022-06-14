import { CommentClass, IComment } from './../../_models/comment';

import { Apartment, ApartmentClass, RentApartmentClass } from 'src/app/_models/apartment';
import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { User } from 'src/app/_models/user';
import { NgForm } from '@angular/forms';
import { AccountService } from 'src/app/_services/account.service';
import { MembersService } from 'src/app/_services/members.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-rent-ap',
  templateUrl: './rent-ap.component.html',
  styleUrls: ['./rent-ap.component.css']
})
export class RentApComponent implements OnInit {
apartment:Apartment
comments:IComment[]
  constructor(public bsModalRef: BsModalRef,public accService:AccountService, public memberService:MembersService,private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loadComments();
  }



  cancel(){
    this.bsModalRef.hide();

  }
  onSubmit(){
    const user: User = JSON.parse(localStorage.getItem('user'));
    const id = this.accService.getUsername(user);
    this.memberService.reApformData.renterId=id;
    this.memberService.reApformData.apartmentId=this.apartment.id
    this.bsModalRef.hide();
    this.rentApartment()
  }
  rentApartment(){

    this.memberService.rentApartment().subscribe(
      res =>{
        this.memberService.reApformData = new RentApartmentClass();
        this.toastr.success('Stan je uspješno objavljen')
        window.location.reload();
      },
      err =>{console.log(err);
     
      });

  }
  
  loadComments(){
    const id = this.apartment.id;
    this.memberService.getCommentById(id).subscribe(commentss=>{
      this.comments = commentss
    })
    console.log(this.comments)
  }
}
