import { Component, OnInit } from '@angular/core';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-new',
  templateUrl: './new.component.html',
  styleUrls: ['./new.component.css']
})
export class NewComponent implements OnInit {
  news:any
  constructor(public memberservice:MembersService) {}

  ngOnInit(): void {
    this.memberservice.getNews().subscribe((data)=>{
      this.news=data['articles']
    })
    
    }
  }


