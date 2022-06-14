import { Apartment } from 'src/app/_models/apartment';

import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Adress } from 'src/app/_models/adress';
import { AccountService } from 'src/app/_services/account.service';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-adding-adress',
  templateUrl: './adding-adress.component.html',
  styleUrls: ['./adding-adress.component.css']
})
export class AddingAdressComponent implements OnInit {
  @Input() apartment: Apartment;
  @Output() cancelAddress = new EventEmitter(); 
  

  constructor(public memberService:MembersService,private accountService: AccountService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }
  cancel (){
    this.cancelAddress.emit(false);
  }
  onSubmit(form:NgForm){
    this.memberService.formData.apartmentId=this.apartment.id
    this.insertAdress(form);
  }
  insertAdress(form:NgForm){
    this.memberService.postAdress().subscribe(
      res =>{
        this.memberService.formData = new Adress();
        this.toastr.success('Adresa uspješno unešena')
        window.setTimeout(function(){location.reload()},2000)
      },
      err =>{console.log(err);}
    );

  }
}
