package org.charles.weilog.service.impl;

import org.charles.weilog.domain.Term;
import org.charles.weilog.service.TermService;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class TermServiceImpl implements TermService {

    @Override
    public boolean add(Term term) {
        return false;
    }

    @Override
    public boolean remove(Long id) {
        return false;
    }

    @Override
    public boolean update(Term term) {
        return false;
    }

    @Override
    public Term query(Long id) {
        return null;
    }

    @Override
    public List<Term> query(String tag) {
        return null;
    }

    @Override
    public List<Term> query(int pageIndex, int pageSize) {
        return null;
    }
}
