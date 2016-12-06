import { Person } from './person';
import { Skill } from './skill';
import { SkillLevel } from './skill-level';
import { TimePeriod } from './time-period';

export class PersonSkill {
  id: number;
  person: Person;
  skill: Skill;
  skillLevel: SkillLevel;
  timeUsed: TimePeriod;
  timeSinceUsed: TimePeriod;

  constructor(id: number, person: Person, skill: Skill, skillLevel: SkillLevel, timeUsed: TimePeriod, timeSinceUsed: TimePeriod) {
    this.id = id;
    this.person = person;
    this.skill = skill;
    this.skillLevel = skillLevel;
    this.timeUsed = timeUsed;
    this.timeSinceUsed = timeSinceUsed;
  }
}
