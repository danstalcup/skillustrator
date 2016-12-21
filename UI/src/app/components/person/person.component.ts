import { Component, OnInit, ViewChild } from '@angular/core';

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

  constructor(private personService: PersonService) { }

  ngOnInit() {
    this.personId = 1;
    this.personService.getById(this.personId).subscribe(person => this.person = person);
  }

  addSkill(): void {
    this.skillsModalComponent.openModal();
  }
}
