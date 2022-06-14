import { CarouselComponent } from './carousel/carousel/carousel.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './Registration/registration.component';
import { MembersDetailComponent } from './apartments/apartmentEditPage/apartmentdetail.component';
import { MembersListComponent } from './apartments/ApartmentForRent/apartmentsforrent.component';
import { AdminGuard } from './_guards/admin.guard';
import { AuthGuard } from './_guards/auth.guard';
import { UserManagementComponent } from './admin/user-management/user-management.component';
import { MyapartmentsComponent } from './apartments/myapartments/myapartments.component';
import { ContactFormComponent } from './contact/contact-form/contact-form.component';
import { NewComponent } from './news/new/new.component';


const routes: Routes = [
  {path: '', component: HomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
   // canActivate: [AuthGuard],
    children: [
        
        {path: 'members',component: MembersListComponent, canActivate: [AuthGuard] },
        {path: 'apEdit',component: MembersDetailComponent,canActivate: [AuthGuard] },
        {path: 'login',component: ListsComponent },
        {path: 'admin',component: UserManagementComponent, canActivate: [AdminGuard]},
        {path: 'myapartments', component: MyapartmentsComponent},
        {path: 'contact', component: ContactFormComponent,canActivate: [AuthGuard]},
        {path: 'news', component: NewComponent}
    ]
  } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
