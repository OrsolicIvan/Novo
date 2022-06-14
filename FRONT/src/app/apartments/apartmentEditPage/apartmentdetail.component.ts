import { Apartment } from '../../_models/apartment';
import { MembersService } from '../../_services/members.service';
import { Component, OnInit } from '@angular/core';
import { NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions } from '@kolkov/ngx-gallery';
import { Member } from 'src/app/_models/member';
import { ActivatedRoute } from '@angular/router';
import { AccountService } from 'src/app/_services/account.service';
import { User } from 'src/app/_models/user';

@Component({
  selector: 'app-members-detail',
  templateUrl: './apartmentdetail.component.html',
  styleUrls: ['./apartmentdetail.component.css']
})
export class MembersDetailComponent implements OnInit {
  member: Member;
  apartments: Apartment[];

  constructor(private memberService: MembersService, private route: ActivatedRoute,private accService: AccountService) { }

  ngOnInit(): void {
    this.loadApartments();
  }

  loadApartments(){
    const user: User = JSON.parse(localStorage.getItem('user'));
   const id = this.accService.getUsername(user);
    this.memberService.getApartmentsById(id).subscribe(apartmentss => {
      this.apartments  = apartmentss ;
    })
    
  }

 
  
}
