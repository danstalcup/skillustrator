import { Component, OnInit, EventEmitter } from '@angular/core';
import { MaterializeAction } from 'angular2-materialize';

import { Skill } from '../../models/skill';
import { SkillsService } from '../../services/skills.service';

@Component({
  selector: 'app-add-person-skill',
  templateUrl: './add-person-skill.component.html',
  styleUrls: ['./add-person-skill.component.css']
})
export class AddPersonSkillComponent implements OnInit {
  modalActions = new EventEmitter<string | MaterializeAction>();
  availableSkills: Skill[];
  selectedSkill: Skill;

  constructor(private skillsService: SkillsService) { }

  ngOnInit() {
    this.skillsService.getAll().subscribe(skills => this.availableSkills = skills);
  }

  openModal() {
    this.modalActions.emit({action: 'modal', params: ['open']});
  }
  closeModal() {
    this.modalActions.emit({action: 'modal', params: ['close']});
  }

}
