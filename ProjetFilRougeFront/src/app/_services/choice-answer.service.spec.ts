import { TestBed } from '@angular/core/testing';

import { ChoiceAnswerService } from './choice-answer.service';

describe('ChoiceAnswerService', () => {
  let service: ChoiceAnswerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ChoiceAnswerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
