import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Apartment, ApartmentClass } from 'src/app/_models/apartment';
import { MembersService } from 'src/app/_services/members.service';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
@Component({
  selector: 'app-create-ap-modal',
  templateUrl: './create-ap-modal.component.html',
  styleUrls: ['./create-ap-modal.component.css']
})
export class CreateApModalComponent implements OnInit {
  
  constructor(public accService:AccountService,public memberService:MembersService,private toastr: ToastrService,public bsModalRef: BsModalRef) { }

  ngOnInit(): void {
  }
  cancel(){
    this.bsModalRef.hide();

  }
  loadApartments(){
    const user: User = JSON.parse(localStorage.getItem('user'));
    const username = this.accService.getUsername(user);
  }
  onSubmit(form:NgForm){
    const user: User = JSON.parse(localStorage.getItem('user'));
    const username = this.accService.getUsername(user);
    this.memberService.apformData.ownerId=username;
    this.bsModalRef.hide();
    this.createApartment()
  }
  createApartment(){
    this.memberService.postApartment().subscribe(
      res =>{
        this.memberService.apformData = new ApartmentClass();
        this.toastr.success('Stan je uspješno objavljen')
      },
      err =>{console.log(err);}
    );

  }
}
