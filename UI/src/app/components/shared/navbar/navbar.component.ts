import { Component, OnInit } from '@angular/core';

import { Person } from '../../../models/person';
import { PersonService } from '../../../services/person.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  currentUserId?: number;
  currentUser: Person;
  isUserLoggedIn: boolean;

  constructor(private personService: PersonService) { }

  ngOnInit() {
    //TODO: Probably can use this when wiring up login
    // this.isUserLoggedIn = !!this.currentUserId;
    // if (this.isUserLoggedIn) {
    //   this.personService.getById(this.currentUserId).subscribe(user => this.currentUser = user);
    // }
  }

}
