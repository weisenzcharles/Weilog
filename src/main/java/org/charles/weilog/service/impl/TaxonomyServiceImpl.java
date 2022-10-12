package org.charles.weilog.service.impl;

import org.charles.weilog.domain.Taxonomy;
import org.charles.weilog.repository.TaxonomyRepository;
import org.charles.weilog.service.TaxonomyService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

/**
 * The type Taxonomy service.
 */
@Service
public class TaxonomyServiceImpl implements TaxonomyService {

    private final TaxonomyRepository taxonomyRepository;

    /**
     * Instantiates a new Taxonomy service.
     *
     * @param taxonomyRepository
     *         the taxonomy repository
     */
    @Autowired
    public TaxonomyServiceImpl(TaxonomyRepository taxonomyRepository) {
        this.taxonomyRepository = taxonomyRepository;
    }

    @Override
    public Taxonomy insert(Taxonomy entity) {
        return taxonomyRepository.save(entity);
    }

    @Override
    public void delete(Long id) {
        taxonomyRepository.deleteById(id);
    }

    @Override
    public Taxonomy update(Taxonomy entity) {
        return taxonomyRepository.save(entity);
    }

    @Override
    public Taxonomy query(Long id) {
        return null;
    }

    @Override
    public List<Taxonomy> query(String title, int pageIndex, int pageSize) {
        return null;
    }

    @Override
    public List<Taxonomy> query(int pageIndex, int pageSize) {
        return null;
    }
}