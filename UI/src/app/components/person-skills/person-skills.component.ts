import { Component, OnInit } from '@angular/core';

import { Skill } from '../../models/skill';
import { PersonSkill } from '../../models/person-skill';
import { SkillsService } from '../../services/skills.service';

@Component({
  selector: 'app-person-skills',
  templateUrl: './person-skills.component.html',
  styleUrls: ['./person-skills.component.css']
})
export class PersonSkillsComponent implements OnInit {


  constructor() { }

  ngOnInit() {
  }

}
