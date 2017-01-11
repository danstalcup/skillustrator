import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';
import { MaterializeAction } from 'angular2-materialize';

import { Skill } from '../../models/skill';
import { SkillLevel } from '../../models/skill-level';
import { TimePeriod } from '../../models/time-period';
import { SkillsService } from '../../services/skills.service';
import { MetadataService } from '../../services/metadata.service';
import { Person } from '../../models/person';
import { PersonSkill } from '../../models/person-skill';
import { PersonService } from '../../services/person.service';

@Component({
  selector: 'app-add-person-skill',
  templateUrl: './add-person-skill.component.html',
  styleUrls: ['./add-person-skill.component.css']
})
export class AddPersonSkillComponent implements OnInit {
  modalActions = new EventEmitter<string | MaterializeAction>();
  availableSkills: Skill[];
  availableSkillLevels: SkillLevel[];
  availableTimePeriods: TimePeriod[];
  selectedSkillId: number;
  selectedSkillLevelCode: string;
  selectedTimeUsedCode: string;
  selectedTimeLastUsedCode: string;
  @Input() person: Person;
  @Output() updatedPerson: EventEmitter<Person> = new EventEmitter<Person>();
  hasError: boolean;
  errors: string[];

  constructor(
    private skillsService: SkillsService, 
    private personService: PersonService, 
    private metadataService: MetadataService) { }

  ngOnInit() {
    this.skillsService.getAll().subscribe(skills => this.availableSkills = skills);
    this.metadataService.getAll().subscribe(skillsMetadata => 
    {
      this.availableSkillLevels = skillsMetadata.skillLevels;
      this.availableTimePeriods = skillsMetadata.timePeriods;
    });
  }

  openModal(): void {
    this.hideError();
    this.modalActions.emit({action: 'modal', params: ['open']});
  }

  closeModal(): void {
    this.hideError();
    this.modalActions.emit({action: 'modal', params: ['close']});
  }

  addSkill(): void {
    this.hasError = false;
    if (this.selectedSkillId) {
      
      var personSkill = {
        personId: this.person.id,
        skillId: this.selectedSkillId,
        skillLevelCode: this.selectedSkillLevelCode,
        timeUsedCode: this.selectedTimeUsedCode,
        timeLastUsedCode: this.selectedTimeLastUsedCode
      };

      this.personService.addPersonSkillWithMetadata(personSkill)
        .subscribe(person => {
          this.person = person;
          this.refreshPerson(this.person);
        });
      this.closeModal();
    } else {
      this.showError();
    }
  }

  refreshPerson(person: Person) {
    this.updatedPerson.emit(person);
  }

  showError(): void {
    this.errors = ['No skill was selected.'];
    this.hasError = true;
  }

  hideError(): void {
    this.errors = [];
    this.hasError = false;
  }
}
