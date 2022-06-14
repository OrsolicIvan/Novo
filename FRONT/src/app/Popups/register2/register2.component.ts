import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_services/account.service';


@Component({
  selector: 'app-register2',
  templateUrl: './register2.component.html',
  styleUrls: ['./register2.component.css']
})
export class Register2Component implements OnInit {
  @Output() cancelRegister = new EventEmitter(); 
  model: any = {};

  constructor(private accountService: AccountService, private toastr: ToastrService,private router: Router) { }

  ngOnInit(): void {
  }

  register2(){
    this.accountService.register2(this.model).subscribe(response => {
      
      
      window.setTimeout(function(){location.reload()},500)
      this.router.navigateByUrl('/')
    }, error => {
      console.log(error);
      this.toastr.error("LOZINKA MORA SADRŽAVATI BAREM 1 VELIKO SLOVO,1 BROJ I MINIMALNO 8 ZNAKOVA");
    })
  }

  cancel (){
    this.cancelRegister.emit(false);
  }

}
