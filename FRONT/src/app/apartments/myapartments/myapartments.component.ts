import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Apartment } from '../../_models/apartment';
import { Member } from '../../_models/member';
import { User } from '../../_models/user';
import { AccountService } from '../../_services/account.service';
import { MembersService } from '../../_services/members.service';

@Component({
  selector: 'app-myapartments',
  templateUrl: './myapartments.component.html',
  styleUrls: ['./myapartments.component.css']
})
export class MyapartmentsComponent implements OnInit {
member:Member;
apartments: Apartment[]

  constructor(private memberService: MembersService, private route: ActivatedRoute,private accService: AccountService) { }

  ngOnInit(): void {
    this.loadReApartments()
  }
  loadReApartments(){
  const user: User = JSON.parse(localStorage.getItem('user'));
   const id = this.accService.getUsername(user);
    this.memberService.getReApartmentBy(id).subscribe(apartmentss => {
      this.apartments  = apartmentss ;
    })
    console.log(this.apartments)
    
  }
}
