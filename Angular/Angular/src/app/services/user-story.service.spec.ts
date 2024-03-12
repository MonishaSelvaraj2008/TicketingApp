import { TestBed } from '@angular/core/testing';

import { UserStoryService } from './user-story.service';

describe('CreateUserStoryService', () => {
  let service: UserStoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserStoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
