import { SkillLevel } from './skill-level';
import { TimePeriod } from './time-period';

export class SkillsMetadata {
  skillLevels: SkillLevel[];
  timePeriods: TimePeriod[];

  constructor(skillLevels: SkillLevel[], timePeriods: TimePeriod[]) {
    this.skillLevels = skillLevels;
    this.timePeriods = timePeriods;
  }
}
