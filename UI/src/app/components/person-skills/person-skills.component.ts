import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';

import { Person } from '../../models/person';
import { PersonService } from '../../services/person.service';

@Component({
  selector: 'app-person-skills',
  templateUrl: './person-skills.component.html',
  styleUrls: ['./person-skills.component.css']
})
export class PersonSkillsComponent implements OnInit {
  @Input() person: Person;
  @Output() updatedPerson: EventEmitter<Person> = new EventEmitter<Person>();

  constructor(
    private personService: PersonService
    ) { }

  ngOnInit() {
  }

  removeSkill(personSkillId) {
    this.personService.removePersonSkill(this.person.id, personSkillId)
      .subscribe(person => {
        this.person = person;
        this.refreshPerson(this.person);
      });
  }

  refreshPerson(person: Person) {
    this.updatedPerson.emit(person);
  }
}
