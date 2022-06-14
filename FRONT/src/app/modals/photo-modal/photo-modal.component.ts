import { Component, OnInit } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { Apartment } from 'src/app/_models/apartment';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { environment } from 'src/environments/environment';


@Component({
  selector: 'app-photo-modal',
  templateUrl: './photo-modal.component.html',
  styleUrls: ['./photo-modal.component.css']
})
export class PhotoModalComponent implements OnInit {
uploader: FileUploader;
hasBaseDropzoneOver = false;
baseUrl = environment.apiUrl;
user: User;
apartment: Apartment;

  constructor(private accountService: AccountService,private toastr: ToastrService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
   }

  ngOnInit(): void {
    this.initializeUploader();
  }

  fileOverBase(e: any){
    this.hasBaseDropzoneOver = e; 
  }
 
  
  initializeUploader(){
    this.uploader = new FileUploader({
      url: this.baseUrl + 'users/add-photo?id=' +  this.apartment.id,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10*1024*1024
    });

    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false;
    }

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if (response){
        console
        if(response=="Stan već ima fotografiju"){
        this.toastr.warning("Stan već ima fotografiju");}
        else {this.toastr.success("Fotografija uspješno uploadana");
        window.setTimeout(function(){location.reload()},2000)}
      }
    }
   }

}
