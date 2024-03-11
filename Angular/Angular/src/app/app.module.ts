import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginModule } from './login/login.module';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login/login.component';
import { CreateUserStoryComponent } from './userStory/create-user-story/create-user-story.component';
import { UpdateUserStoryComponent } from './userStory/update-user-story/update-user-story.component';
import { CreateBugComponent } from './bug/create-bug/create-bug.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CreateCustomerSupportComponent } from './customerSupport/create-customer-support/create-customer-support.component';
import { UserStoryListComponent } from './userStory/user-story-list/user-story-list.component';
import { UserStoryDescriptionComponent } from './userStory/user-story-description/user-story-description.component';
import { UpdateBugComponent } from './bug/update-bug/update-bug.component';
import { ViewUserStoryHistoryComponent } from './userStory/view-user-story-history/view-user-story-history.component';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatMenuModule } from '@angular/material/menu';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTooltipModule } from '@angular/material/tooltip';
import { ResponsibleTicketsComponent } from './responsible-tickets/responsible-tickets.component';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';


@NgModule({
  declarations: [
    AppComponent,
      HomeComponent,
      HeaderComponent,
      FooterComponent,
      DashboardComponent,
      LoginComponent,
      CreateBugComponent,
    CreateUserStoryComponent,
    UpdateUserStoryComponent,
    CreateCustomerSupportComponent,
    UserStoryListComponent,
    UserStoryDescriptionComponent,
    UpdateBugComponent,
    ViewUserStoryHistoryComponent,
    ResponsibleTicketsComponent,
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LoginModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    ToastrModule.forRoot({preventDuplicates: false,}),
    MatTableModule,
    MatToolbarModule,
    MatButtonModule,
    MatCardModule,
    MatInputModule,
    MatDialogModule,
    MatMenuModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatIconModule,
    MatPaginatorModule,
    MatTooltipModule,
    MatSelectModule,
    MatSidenavModule,
    MatListModule,
    MatSlideToggleModule
  ],
  providers: [ToastrService],
  bootstrap: [AppComponent]
})
export class AppModule { }
