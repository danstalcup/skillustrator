import { Component, OnInit, Input } from '@angular/core';

import { Skill } from '../../models/skill';

@Component({
  selector: 'app-person-skills',
  templateUrl: './person-skills.component.html',
  styleUrls: ['./person-skills.component.css']
})
export class PersonSkillsComponent implements OnInit {
  @Input() skills: Skill[];

  constructor() { }

  ngOnInit() {
  }

}
