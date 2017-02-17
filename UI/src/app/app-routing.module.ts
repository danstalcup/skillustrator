import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { PersonComponent } from './components/person/person.component';
//import { PersonDashboardComponent } from './components/person-dashboard/person-dashboard.component';
import { SkillsComponent } from './components/skills/skills.component';
import { TagsComponent } from './components/tags/tags.component';
import { SearchComponent } from './components/search/search.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'person/:id', component: PersonComponent },
  { path: 'manage-skills', component: SkillsComponent },
  { path: 'manage-tags', component: TagsComponent },
  { path: 'search', component: SearchComponent }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
