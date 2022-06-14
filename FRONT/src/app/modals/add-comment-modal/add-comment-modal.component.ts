import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Apartment } from 'src/app/_models/apartment';
import { CommentClass } from 'src/app/_models/comment';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-add-comment-modal',
  templateUrl: './add-comment-modal.component.html',
  styleUrls: ['./add-comment-modal.component.css']
})
export class AddCommentModalComponent implements OnInit {

  constructor(public bsModalRef: BsModalRef, public memberService:MembersService,private toastr: ToastrService) { }
  apartment:Apartment;
  comment: CommentClass
  ngOnInit(): void {
  }
  cancel(){
    this.bsModalRef.hide();

  }
  onSubmit(form:NgForm){
    this.memberService.comformData.apartmentId = this.apartment.id
    
    this.postComment(form);
  }
  postComment(form:NgForm){
    this.memberService.postComment().subscribe(
      res=>{
        this.memberService.comformData = new CommentClass();
        this.toastr.success("Ostavili ste dojam");
        this.cancel();
        
      }
    )

  }
}
// onSubmit(form:NgForm){
//   const user: User = JSON.parse(localStorage.getItem('user'));
//   const id = this.accService.getUsername(user);
//   this.memberService.reApformData.renterId=id;
//   this.memberService.reApformData.apartmentId=this.apartment.id
//   this.bsModalRef.hide();
//   this.rentApartment(form)
// }
// rentApartment(form:NgForm){

//   this.memberService.rentApartment().subscribe(
//     res =>{
//       this.memberService.reApformData = new RentApartmentClass();
//       this.toastr.success('Stan je uspješno objavljen')
//       window.location.reload();
//     },
//     err =>{console.log(err);
   
//     });

// }