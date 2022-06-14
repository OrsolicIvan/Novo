import { AccountService } from '../_services/account.service';
import { ActivatedRoute } from '@angular/router';
import { MembersService } from '../_services/members.service';
import { Member } from 'src/app/_models/member';
import { Component, Input, OnInit } from '@angular/core';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from '@kolkov/ngx-gallery';

@Component({
  selector: 'app-lists',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class ListsComponent implements OnInit {
  registerMode = false;
  registerMode2 = false;
  registerShow = true;

  constructor(public accountService:AccountService) { }

  ngOnInit(): void {}

  registerToggle(){
    this.registerMode = !this.registerMode;
    this.registerShow = !this.registerShow;
  }
  registerToggle2(){
    this.registerMode2 = !this.registerMode2;
    this.registerShow = !this.registerShow;
  }
  cancelRegisterMode(event: boolean) {
    this.registerMode = event;  
    this.registerShow = !this.registerShow;
  }
  cancelRegisterMode2(event: boolean) {
    this.registerMode2 = event;  
    this.registerShow = !this.registerShow;
  }
 

}
