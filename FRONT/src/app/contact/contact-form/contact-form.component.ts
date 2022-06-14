import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.css']
})
export class ContactFormComponent implements OnInit {

  constructor(private toastr: ToastrService, private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(){
    this.toastr.success('Upit uspješno poslan')
    setTimeout(() => {
      this.router.navigate(['/']);
  }, 2000);
    
    
  }
  
}
