import { TestBed } from '@angular/core/testing';

import { PassageQuizzService } from './passage-quizz.service';

describe('PassageQuizzService', () => {
  let service: PassageQuizzService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PassageQuizzService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
