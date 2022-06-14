import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AdminService } from 'src/app/_services/admin.service';

@Component({
  selector: 'app-delete-user-dialog',
  templateUrl: './delete-user-dialog.component.html',
  styleUrls: ['./delete-user-dialog.component.css']
})
export class DeleteUserDialogComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public user: any,private adminService:AdminService) { }

  ngOnInit(): void {
  }
  
  deleteUser(username:string){
    
    this.adminService.deleteUser(username).subscribe(result =>{
      window.location.reload()
        
      },
      err =>{console.log(err);});
  }
}
