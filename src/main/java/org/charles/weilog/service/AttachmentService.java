package org.charles.weilog.service;

import org.charles.weilog.domain.Attachment;
import org.charles.weilog.domain.Taxonomy;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface AttachmentService {
    boolean add(Attachment attachment);

    boolean remove(Long id);

    boolean update(Attachment attachment);

    Attachment query(Long id);

    List<Attachment> query(String title, int pageIndex, int pageSize);

    List<Attachment> query(int pageIndex, int pageSize);
}