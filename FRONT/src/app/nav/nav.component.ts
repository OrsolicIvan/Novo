import { CreateApModalComponent } from './../modals/create-ap-modal/create-ap-modal.component';
import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import {  BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef} from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any ={}
  bsModalRef: BsModalRef;

  constructor(public accountService: AccountService, private router: Router, 
    private toastr: ToastrService,private modalService: BsModalService) { }

  ngOnInit(): void {
  
  
    
  }

  login() {
    this.accountService.login(this.model).subscribe(response => {
      this.router.navigateByUrl('/members')
      window.location.reload();
    }, error =>{
      console.log(error);
      this.toastr.error("Neispravno korisnicko ime ili lozinka");
    })
  }

  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/')
    window.setTimeout(function(){location.reload()},500)
  }
  btnClick= function () {
    this.router.navigateByUrl('/login');
    
}
openApCreateModal(){
  const config = {
    class: 'modal-dialog-centered',
    
  }
  this.bsModalRef = this.modalService.show(CreateApModalComponent,config);
  
  
}
}
