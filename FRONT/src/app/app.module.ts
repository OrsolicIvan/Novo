import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import {MatButtonModule} from '@angular/material/button';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './Popups/register/register.component';
import { MembersListComponent } from './apartments/ApartmentForRent/apartmentsforrent.component';
import { MembersDetailComponent } from './apartments/apartmentEditPage/apartmentdetail.component';
import { ListsComponent } from './Registration/registration.component';
import { SharedModule } from './_modules/shared.module';
import { HasRoleDirective } from './_directives/has-role.directive';
import { UserManagementComponent } from './admin/user-management/user-management.component';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { Register2Component } from './Popups/register2/register2.component';
import { RolesModalComponent } from './modals/roles-modal/roles-modal.component';
import { MemberCardComponent } from './apartments/ApartmentForRent/ApartmentForRentcard/apartmentforrentcard.component';
import { ApartmentCardComponent } from './apartments/apartmentEditPage/apartment-card/apartment-card.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AddingAdressComponent } from './Popups/adding-adress/adding-adress.component';
import { CarouselComponent } from './carousel/carousel/carousel.component';
import { CreateApModalComponent } from './modals/create-ap-modal/create-ap-modal.component';
import { MyapartmentsComponent } from './apartments/myapartments/myapartments.component';
import { RentApComponent } from './modals/rent-ap/rent-ap.component';
import { PhotoModalComponent } from './modals/photo-modal/photo-modal.component';
import {MatDialogModule} from '@angular/material/dialog';
import { MyApartmentCardComponent } from './apartments/myapartments/my-apartment-card/my-apartment-card.component';
import {MatInputModule} from '@angular/material/input';
import { MatIconModule} from '@angular/material/icon';
import { ReactiveFormsModule } from '@angular/forms';
import { AddCommentModalComponent } from './modals/add-comment-modal/add-comment-modal.component';
import { SearchFilter } from './search/search-filter/search-filter.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { ContactFormComponent } from './contact/contact-form/contact-form.component';
import { Filter } from './filter/filter.component';
import { MatSelectModule} from '@angular/material/select';
import { NewComponent } from './news/new/new.component';
import { DeleteUserDialogComponent } from './Popups/delete-user-dialog/delete-user-dialog.component';
import { SidenavComponent } from './sidenav/sidenav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    MembersListComponent,
    MembersDetailComponent,
    ListsComponent,
    HasRoleDirective,
    UserManagementComponent,
    Register2Component,
    RolesModalComponent,
    MemberCardComponent,
    ApartmentCardComponent,
    AddingAdressComponent,
    CarouselComponent,
    CreateApModalComponent,
    MyapartmentsComponent,
    RentApComponent,
    PhotoModalComponent,
    MyApartmentCardComponent,
    AddCommentModalComponent,
    SearchFilter,
    ContactFormComponent,
    Filter,
    NewComponent,
    DeleteUserDialogComponent,
    SidenavComponent,
  ],
  imports: [
    MatInputModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    SharedModule,
    TabsModule,
    MatButtonModule,
    FontAwesomeModule,
    NgbModule,
    MatDialogModule,
    MatIconModule,
    ReactiveFormsModule,
    Ng2SearchPipeModule,
    MatSelectModule,
    LayoutModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents: [RolesModalComponent,CreateApModalComponent]
})
export class AppModule { }
