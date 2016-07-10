using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LeadisTeam.LeadisJourney.Core.Entities;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Repositories.NHibernate;

namespace LeadisTeam.LeadisJourney.Repositories {
    public class SourceRepository : ISourceRepository {
        private readonly TutorialSourceRepository _tutorialSourceRepository;
        private readonly HelpSourceRepository _helpSourceRepository;
        private readonly ExerciceSourceRepository _exerciceSourceRepository;

        public SourceRepository(IScopeFactory scopeFactory) {
            _helpSourceRepository = new HelpSourceRepository(scopeFactory);
            _tutorialSourceRepository = new TutorialSourceRepository(scopeFactory);
            _exerciceSourceRepository = new ExerciceSourceRepository(scopeFactory);
        }

        private void Call(Source source, string methodName) {
            if (source is HelpSource) {
                var methodInfo = typeof (HelpSourceRepository).GetMethod(methodName);
                methodInfo.Invoke(_helpSourceRepository, new object[] {
                    (HelpSource)source
                });
            }
            else if (source is TutorialSource) {
                _tutorialSourceRepository.Save((TutorialSource)source);
            }
            else if (source is ExerciceSource) {
                _exerciceSourceRepository.Save((ExerciceSource)source);
            }
            else {
                throw new InvalidOperationException("Wrong type of source");
            }
        }

        private void Call(IEnumerable<Source> entities, string methodName) {
            var type = entities.GetType().GetGenericArguments().Single();
            if (type.IsAssignableFrom(typeof (HelpSource))) {
                var methodInfo = typeof(HelpSourceRepository).GetMethod(methodName);
                methodInfo.Invoke(_helpSourceRepository, new object[] {
                    entities
                });
            }
        }

        public void Save(Source entity) {
            if (entity is HelpSource) {
                _helpSourceRepository.Save((HelpSource) entity);
            }
            else if (entity is TutorialSource) {
                _tutorialSourceRepository.Save((TutorialSource) entity);
            }
            else if (entity is ExerciceSource) {
                _exerciceSourceRepository.Save((ExerciceSource) entity);
            }
            else {
                throw new InvalidOperationException("Wrong type of source");
            }
        }

        public void Save(IEnumerable<Source> entities) {
            Call(entities, "Save");
        }

        public void Delete(Source entity) {
            Call(entity, "Delete");
        }

        public void Delete(IEnumerable<Source> entities) {
            throw new NotImplementedException();
        }

        public IQueryable<Source> All() {
            throw new NotImplementedException();
        }

        public IQueryable<Source> FilterBy(Expression<Func<Source, bool>> expression) {
            throw new NotImplementedException();
        }

        public Source FindBy(int id) {
            throw new NotImplementedException();
        }

        public Source FindBy(Expression<Func<Source, bool>> expression) {
            throw new NotImplementedException();
        }
    }

    internal class ExerciceSourceRepository : Repository<ExerciceSource> {
        public ExerciceSourceRepository(IScopeFactory scopeFactory) : base(scopeFactory) {
        }
    }

    internal class TutorialSourceRepository : Repository<TutorialSource> {
        public TutorialSourceRepository(IScopeFactory scopeFactory) : base(scopeFactory) {
        }
    }

    internal class HelpSourceRepository : Repository<HelpSource> {
        public HelpSourceRepository(IScopeFactory scopeFactory) : base(scopeFactory) {
        }
    }
}