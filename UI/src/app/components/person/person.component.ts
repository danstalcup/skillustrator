import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Person } from '../../models/person';
import { PersonService } from '../../services/person.service';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {
  @ViewChild('skillsModal') skillsModalComponent;
  personId: number;
  person: Person;

  constructor(
    private personService: PersonService,
    private route: ActivatedRoute
    ) { }

  ngOnInit() {
    this.route.params
      .map(params => params['id'])
      .switchMap(id => this.personService.getById(id))
      .subscribe(person => this.person = person);
  }

  addSkill(): void {
    this.skillsModalComponent.openModal();
  }
}
