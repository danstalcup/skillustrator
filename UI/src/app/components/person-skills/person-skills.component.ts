import { Component, OnInit, Input } from '@angular/core';

import { Person } from '../../models/person';

@Component({
  selector: 'app-person-skills',
  templateUrl: './person-skills.component.html',
  styleUrls: ['./person-skills.component.css']
})
export class PersonSkillsComponent implements OnInit {
  @Input() person: Person;

  constructor() { }

  ngOnInit() {
  }

}
