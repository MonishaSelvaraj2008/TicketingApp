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
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LoginModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
