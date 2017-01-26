import { Component, OnInit } from '@angular/core';

import { Skill } from '../../models/skill';
import { SkillsService } from '../../services/skills.service';

@Component({
  selector: 'app-skills',
  templateUrl: './skills.component.html',
  styleUrls: ['./skills.component.css']
})
export class SkillsComponent implements OnInit {
  skills: Skill[];
  newSkillName: string;

  constructor(private skillsService: SkillsService) { }

  ngOnInit() {
    this.skillsService.getAll().subscribe(skills => this.skills = skills);
  }

  addSkill() {
    let newSkill = new Skill(this.newSkillName);
    this.skillsService.create(newSkill).subscribe(skill => {
      this.skills.push(skill);
      this.newSkillName = "";
    });
  }

  deleteSkill(id) {
    this.skillsService.delete(id).subscribe(() => {

      var deletedIndex = this.skills.findIndex(function(skill) {
        return skill.id == id;
      });

      this.skills.splice(deletedIndex, 1);

    });
  }
}