// External imports
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

// Internal imports
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HttpService } from './services/http.service';
import { PersonService } from './services/person.service';
import { SkillsService } from './services/skills.service';
import { TagsService } from './services/tags.service';
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { HomeComponent } from './components/home/home.component';
import { PersonComponent } from './components/person/person.component';
import { PersonSkillsComponent } from './components/person-skills/person-skills.component';
import { SkillsComponent } from './components/skills/skills.component';
import { TagsComponent } from './components/tags/tags.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    PersonComponent,
    PersonSkillsComponent,
    SkillsComponent,
    TagsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule
  ],
  providers: [
    HttpService,
    PersonService,
    SkillsService,
    TagsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
