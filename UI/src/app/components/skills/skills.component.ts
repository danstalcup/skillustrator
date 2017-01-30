import { Component, OnInit } from '@angular/core';

import { Skill } from '../../models/skill';
import { SkillsService } from '../../services/skills.service';
import { Subscription } from "rxjs/Rx";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-skills',
  templateUrl: './skills.component.html',
  styleUrls: ['./skills.component.css']
})
export class SkillsComponent implements OnInit {
  skills: Skill[];
  newSkillName: string;
  subscription: Subscription;
  filterTag: string;

  constructor(private skillsService: SkillsService, private route: ActivatedRoute) { 
    this.subscription = route.queryParams.subscribe(
        (queryParam: any) => this.filterTag = queryParam['tag']
    );
  }

  ngOnInit() {
    if (this.filterTag == null || this.filterTag == "") {
      this.skillsService.getAll().subscribe(skills => {
        this.skills = skills;
      });
    } else {
      this.skillsService.getByTag(this.filterTag).subscribe(skills => {
        this.skills = skills;
      });
    }
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
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