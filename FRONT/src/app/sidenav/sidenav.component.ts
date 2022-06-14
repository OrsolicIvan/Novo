import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { AccountService } from '../_services/account.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CreateApModalComponent } from '../modals/create-ap-modal/create-ap-modal.component';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.css']
})
export class SidenavComponent {
  model: any ={}
  bsModalRef: BsModalRef;
  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver,public accountService: AccountService, private router: Router, 
    private toastr: ToastrService,private modalService: BsModalService) {}
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
