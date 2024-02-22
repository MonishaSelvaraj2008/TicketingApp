import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login/login.component';
import { CreateUserStoryComponent } from './userStory/create-user-story/create-user-story.component';
import { UpdateUserStoryComponent } from './userStory/update-user-story/update-user-story.component';
import { CreateBugComponent } from './bug/create-bug/create-bug.component';

const routes: Routes = [
  
  {path: '', component: LoginComponent},
  {path: 'createUserStory', component:CreateUserStoryComponent },
  {path: 'updateUserStory', component:UpdateUserStoryComponent },
  {path: 'createBug', component:CreateBugComponent },
  {
    path: 'app',
    loadChildren: () => import('./application/application.module').then(m => m.ApplicationModule)
  }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
