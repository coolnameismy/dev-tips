````js
function DataRepository() { // Singleton pattern
  if (typeof DataRepository.instance === 'object') {
    return DataRepository.instance;
  }

  DataRepository.instance = this;
}

````